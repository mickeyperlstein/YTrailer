using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FinalWebApp.Models;
using System.Threading;

namespace APTService
{
    class Program
    {
        public static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {

            logger.Debug("Starting service");
            YTrailer apt = new YTrailer();

            while (true)
            {

                try
                {
                    Task.Factory.StartNew(()=>apt.Run()).Wait();
                    Thread.Sleep(1000 * 1000);
                }
                catch (System.Net.Http.HttpRequestException )
                {
                    logger.Debug("Cannot reach server, check server is alive");

                }
                catch (AggregateException ae)
                {
                    if (ae.InnerExceptions.OfType<HttpRequestException>().Count() > 0)
                    {
                        logger.Debug("Cannot reach server, check server is alive");

                    }
                    else
                        foreach (var ex in ae.InnerExceptions)
                        {
                            logger.Debug(ex);
                        }
                    Thread.Sleep(2000);

                }
                catch (Exception e)
                {
                    logger.Debug("Failed to RunAsync");
                    logger.Debug(e);
                }
            }
        }


    }
}
