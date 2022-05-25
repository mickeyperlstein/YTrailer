Imports System.Threading
Imports System.ComponentModel

Public Class AbortableBackgroundWorker
    Inherits BackgroundWorker
    Public Sub New()
        Me.WorkerSupportsCancellation = True
        Me.WorkerReportsProgress = True
    End Sub
    Public Sub RunWork(objectState As Object)
        Dim args As New DoWorkEventArgs(objectState)
        Dim eee As Exception = Nothing
        Try
            OnDoWork(args)
        Catch ex As Exception
            eee = ex
        End Try
        OnRunWorkerCompleted(New RunWorkerCompletedEventArgs(args.Result, eee, args.Cancel))
    End Sub
    Public Property Tag() As Object
        Get
            Return m_Tag
        End Get
        Set(value As Object)
            m_Tag = value
        End Set
    End Property
    Private m_Tag As Object
    Private workerThread As Thread

    Protected Overrides Sub OnDoWork(e As DoWorkEventArgs)
        workerThread = Thread.CurrentThread
        Try
            MyBase.OnDoWork(e)
            workerThread = Nothing
        Catch generatedExceptionName As ThreadAbortException
            e.Cancel = True
            'We must set Cancel property to true!
            'Prevents ThreadAbortException propagation
            Thread.ResetAbort()
        End Try
    End Sub
    ''' <summary>
    ''' Kill the background thread
    ''' </summary>
    Public Sub Abort()
        If Not IsBusy Then
            Return
        End If
        Me.CancelAsync()
        Try
            If workerThread IsNot Nothing Then
                workerThread.Abort()
                workerThread = Nothing
            End If
        Catch
        End Try
    End Sub
End Class


