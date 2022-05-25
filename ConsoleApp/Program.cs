using System;
using System.IO;
using System.Linq;
using VisioForge.Controls.VideoEdit;
using VisioForge.Types;

class Program
{
    // Folder contains images
    private static string AssetDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

    // Images
    private static  string[] Images = new string[] { "1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg" };

    static void Main(string[] args)
    {


        var ve = new VisioForge.Controls.VideoEdit.VideoEditCore() { ConsoleUsage = true };
        
        AssetDir = new DirectoryInfo(AssetDir).FullName;

        var outputFile = Path.Combine(Environment.CurrentDirectory, "output.avi");
        Console.WriteLine("*\n*\nBUIDLING VIDEO FILE - {0} \n*\n*",outputFile);
        
        if (File.Exists(outputFile))
        {
            File.Delete(outputFile);
        }
        int insertTime = 0;
        Images = Directory.GetFiles(AssetDir, "*.jpg");
        foreach (string img in Images.Take(8))
        {
            ve.Input_AddImageFile(img, 2000, insertTime, VisioForge.Types.VFVideoEditStretchMode.Letterbox);
          // ve.Video_Effect_Ex()
            insertTime += 10 + 2000;
            Console.WriteLine("Adding {0} for {1:N0} secs", img, insertTime);
        }

        ve.Video_Effects_Clear();
        ve.Mode = VisioForge.Types.VFVideoEditMode.Convert;

        ve.Video_Resize = true;
        ve.Video_Resize_Width = 640;
        ve.Video_Resize_Height = 480;

        ve.Video_FrameRate = 25;
        ve.Video_Renderer = VFVideoRendererInternal.None;
        //ve.Screen_Stretch =  false;

        ve.Output_Format = VFVideoEditOutputFormat.AVI;
        ve.Output_Filename = outputFile;

        ve.Video_Codec = "MJPEG Compressor";

        ve.Video_Effects_Enabled = true;
        ve.Video_Effects_Clear();

        ve.OnError += VideoEdit1_OnError;
        ve.OnProgress += VeOnOnProgress;
        ve.OnStop += ve_OnStop;
        ve.ConsoleUsage = true;

        ve.Start();
    }

    static void ve_OnStop(object sender, EventArgs e)
    {
        Console.WriteLine("STOPPED");
        Console.WriteLine("start \"{0}\"", (sender as VideoEditCore).Output_Filename);
        Console.Read();
    }

    private static void VeOnOnProgress(object sender, ProgressEventArgs progressEventArgs)
    {
        Console.WriteLine(progressEventArgs.Progress);
    }

    private static void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
    {
        Console.WriteLine(e.Message);
    }
}