using APT.core;
using APTService.Properties;
using FinalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APTService
{
    public class YTrailer
    {


        public static bool isAsync = false;
        public static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Task<VideoAnalysisReport> DownloadVideoAsync(PromoRequest item)
        {
            return Task.Factory.StartNew(() =>
            {

                return DownloadVideo(item);
            });
        }

        protected virtual VideoAnalysisReport DownloadVideo(PromoRequest item)
        {
            Thread.Sleep(30000);
            VideoAnalysisReport report = new VideoAnalysisReport()
            {
                PromoRequestId = item.Id,
                OriginalVideo = "OrigFile.avi"
            };

            logger.Debug(report);
            item.Status = ePromoStatus.DownloadingOriginalVideo;
            return report;
        }

        private Task<YouTubeInfos> GetYouTubeDetailsAsync(PromoRequest item)
        {
            return Task.Factory.StartNew(() =>
            {
                YouTubeInfos info = GetYouTubeDetails(item);

                return info;
            });

        }

        protected virtual YouTubeInfos GetYouTubeDetails(PromoRequest item)
        {
            logger.DebugFormat("connecting to yourtube on [{0}]", item.YoutTubeUrl);


            Engine engine = new Engine(@"C:\dev\cache", item.YoutTubeUrl);
            YouTubeVideo video = engine.DownloadYouTubePartsAsync().Result as YouTubeVideo;


            YouTubeInfos info = new YouTubeInfos
            {
                Description = video.Snippet.Description,
                Title = video.Snippet.Title,
                PromoRequestId = item.Id,
                PromoRequest = item
            };

            logger.DebugFormat("Recieved youtube information");
            return info;
        }

        [DebuggerStepThrough]
        private VideoAnalysisReport Insert(VideoAnalysisReport Analysis)
        {
            var url = "api/VideoAnalysisReport";
            return Insert(Analysis, url).Result;
        }

        [DebuggerStepThrough]
        private void Update(VideoAnalysisReport Analysis)
        {
            var url = "api/VideoAnalysisReport/" + Analysis.Id;
            Update(Analysis, url);

        }

        [DebuggerStepThrough]
        private void Update(PromoProject project)
        {
            var url = "api/PromoProject/" + project.Id;
            Update(project, url);

        }
        [DebuggerStepThrough]
        private void Update(PromoRequest request)
        {
            logger.DebugFormat("update ReqId={0} Mode: {1}", request.Id, request.Status.ToString());
            var url = "api/PromoRequest/" + request.Id;
            Update(request, url);

        }
        [DebuggerStepThrough]
        private PromoRequest Insert(PromoRequest request)
        {

            var url = "api/PromoRequest/";
            return Insert(request, url).Result;
        }
        [DebuggerStepThrough]
        private PromoProject Insert(PromoProject proj)
        {
            var url = "api/PromoProject/";
            return Insert(proj, url).Result;
        }

        [DebuggerStepThrough]
        private YouTubeInfos Insert(YouTubeInfos item)
        {
            item.PromoRequest = null;
            var url = "api/YouTube";
            return Insert(item, url).Result;
        }

        [DebuggerStepThrough]
        private void Update(YouTubeInfos item)
        {
            var url = "api/YouTube/" + item.Id;
            Update(item, url);
        }
        [DebuggerStepThrough]
        private async void Update<T>(T item, string url)
        {
            var client = new HttpClient();
            {
                client.BaseAddress = new Uri(Settings.Default.server_url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =
                  isAsync
                  ? (await client.PutAsJsonAsync(url, item))
                  : client.PutAsJsonAsync(url, item).Result;

                if (response.IsSuccessStatusCode)
                {

                    Uri gizmoUrl = response.Headers.Location;
                    logger.DebugFormat("Update to PromoRequest success code={0}", response.StatusCode);
                    // HTTP PUT

                    // response = await client.PutAsJsonAsync(gizmoUrl, item);

                    // HTTP DELETE
                    // response = await client.DeleteAsync(gizmoUrl);
                }
                else
                {
                    logger.ErrorFormat("Post to PromoRequest failed code={0}", response.StatusCode);
                }
            }
        }
        [DebuggerStepThrough]
        private async Task<T> Insert<T>(T item, string url) where T : class
        {
            // HTTP POST
            var client = new HttpClient();

            {
                client.BaseAddress = new Uri(Settings.Default.server_url);// Origclient.BaseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response =
                  isAsync
                  ? (await client.PostAsJsonAsync(url, item))
                  : client.PostAsJsonAsync(url, item).Result;


                //var response = await client.PostAsJsonAsync(promoUrl, item);
                if (
                    //response.IsSuccessStatusCode && 
                    response.IsSuccessStatusCode)
                {

                    item =

                       (isAsync) ?
                       await response.Content.ReadAsAsync<T>() :
                        response.Content.ReadAsAsync<T>().Result;

                    Uri gizmoUrl = response.Headers.Location;
                    logger.DebugFormat("INSERT to {1} success code={0}", response.StatusCode, typeof(T).Name);
                    // HTTP PUT
                    return item;

                }
                else
                {
                    logger.ErrorFormat("INSERT to {1} failed code={0}", response.StatusCode, typeof(T).Name);


                }
                //return response.IsSuccessStatusCode;
            }
            return null;
        }

        [DebuggerStepThrough]
        private async Task<T> Get<T>(int key, string action_url) where T : class
        {
            var url = string.Format("{0}{2}{1}"
                , action_url
                , key
                , (action_url.EndsWith("/") ? string.Empty : "/"));

            // HTTP POST
            var client = new HttpClient();

            {
                client.BaseAddress = new Uri(Settings.Default.server_url);// Origclient.BaseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response =
                  isAsync
                  ? (await client.GetAsync(url))
                  : client.GetAsync(url).Result;


                //var response = await client.PostAsJsonAsync(promoUrl, item);
                if (
                    //response.IsSuccessStatusCode && 
                    response.IsSuccessStatusCode)
                {

                    var obj =

                       (isAsync) ?
                       await response.Content.ReadAsAsync<T>() :
                        response.Content.ReadAsAsync<T>().Result;


                    return obj;
                }
                else
                {
                    logger.ErrorFormat("INSERT to {1} failed code={0}", response.StatusCode, typeof(T).Name);

                }
                //return response.IsSuccessStatusCode;
            }
            //return false;
            return null;
        }
        public async void Run()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Settings.Default.server_url);// "http://localhost:20000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = "api/PromoRequest";
                // New code:
                HttpResponseMessage response =
                    (isAsync) ?
                    await client.GetAsync(url)
                    : client.GetAsync(url).Result;


                if (response.IsSuccessStatusCode)
                {

                    var promoRequests =

                        (isAsync) ?
                        await response.Content.ReadAsAsync<List<PromoRequest>>()
                        : response.Content.ReadAsAsync<List<PromoRequest>>().Result;

                    logger.DebugFormat("Loaded {0} Requests", promoRequests.Count());


                    if (isAsync)
                        Parallel.ForEach(promoRequests, x => DoByStatus(x));
                    else
                        foreach (var item in promoRequests)
                        {
                            DoByStatus(item);
                        }

                }
            }
        }




        public virtual async void Step3_2_Analyzing(PromoRequest item)
        {
            var url = "api/ByRequestId/VideoAnalysisReport/";

            VideoAnalysisReport Analysis =
                (isAsync) ?
                await Get<VideoAnalysisReport>(item.Id, url)
                : Get<VideoAnalysisReport>(item.Id, url).Result;

            item.Status = ePromoStatus.Analyzing;
            Update(item);

            if (isAsync)
                await AnalyzeScenesAsync(Analysis);
            else
                AnalyzeScenes(Analysis);

            Update(Analysis);
        }
        Random random = new Random(13);
        private async void DoByStatus(PromoRequest item)
        {

            while (item.Status != ePromoStatus.ReadyToCreatePromo)
            {
                int secs = random.Next(1000, 4000);
                logger.DebugFormat("■ Randomly stopping for {0:N0} secs", secs / 1000);
                Thread.Sleep(secs);
                switch (item.Status)
                {
                    case ePromoStatus.NotStarted:
                        Step1_GetYouTube(item);
                        break;
                    case ePromoStatus.GettingYouTubeDetails:
                        Step2_1_DownloadingOriginalVideo(item);
                        break;
                    case ePromoStatus.DownloadingOriginalVideo:
                        Step2_2_TestIfStuck(item);
                        break;
                    case ePromoStatus.DownloadedOriginalVideo:
                        Step3_1_CreatingLowResVideo(item);
                        break;
                    case ePromoStatus.CreatingLowResVideo:
                        Step3_2_Analyzing(item);
                        break;
                    case ePromoStatus.Analyzing:
                        Step_4_GettingReadyToMakePromo(item);
                        break;
                    case ePromoStatus.ReadyToCreatePromo:
                        //User input
                        break;
                    case ePromoStatus.CreatingPromo:
                        Step5_CreatingPromo(item);
                        break;
                    case ePromoStatus.Done:
                        Step_6_Return(item);
                        break;
                    default:
                        break;
                }
            }
        }

        private async void Step_6_Return(PromoRequest item)
        {
            item.Status = ePromoStatus.ReadyToCreatePromo;

            await MakeAndInsertNewPromo(item);

            Update(item);

        }

        private async Task MakeAndInsertNewPromo(PromoRequest item)
        {
            PromoProject proj =
                (isAsync) ?
               await Get<PromoProject>(item.Id, "api/ByRequestId/PromoProject/")
               : Get<PromoProject>(item.Id, "api/ByRequestId/PromoProject/").Result;

            YouTubeInfos details = null;


            if (proj == null)
            {
                proj = MakeProject(item, ref details);
            }
            else
            {
                details = (isAsync) ?
               await Get<YouTubeInfos>(item.Id, "api/ByRequestId/YouTubeInfos/")
               : Get<YouTubeInfos>(item.Id, "api/ByRequestId/YouTubeInfos/").Result;
            }

            proj.YouTubeInfosId = details.Id;
            proj.PromoRequestId = item.Id;

            Insert(proj);
        }

        private PromoProject MakeProject(PromoRequest item, ref YouTubeInfos youtube)
        {
            youtube = Get<YouTubeInfos>(item.Id, "api/ByRequestId/YouTubeInfos/").Result;

            var proj =
                new PromoProject
                {
                    StartingTitle = youtube.Title,
                    MidTitle = youtube.Description
                    ,
                    PromoRequestId = item.Id
                    ,
                    YouTubeInfosId = youtube.Id
                };


            return proj;
        }



        private void Step2_2_TestIfStuck(PromoRequest item)
        {
            ManualResetEvent mre = new ManualResetEvent(false);
            mre.WaitOne(30000);
            var newItem = Get<PromoRequest>(item.Id, "api/PromoRequest/").Result;
            if (newItem.Status == ePromoStatus.DownloadingOriginalVideo)
            {
                item.Status = newItem.Status = ePromoStatus.GettingYouTubeDetails;
                Update(newItem);

            }
        }

        private void Step_4_GettingReadyToMakePromo(PromoRequest item)
        {
            YouTubeInfos youtube = new YouTubeInfos();

            var proj = MakeProject(item, ref youtube);
            Insert(proj);
            item.Status = ePromoStatus.ReadyToCreatePromo;
            Update(item);
        }


        private async void Step5_CreatingPromo(PromoRequest item)
        {
            PromoProject proj =
                 (isAsync) ?
                await Get<PromoProject>(item.Id, "api/ByRequestId/PromoProject/")
                : Get<PromoProject>(item.Id, "api/ByRequestId/PromoProject/").Result;

            if (isAsync)
                await CreatePromoAsync(proj);
            else
                CreatePromo(proj);

            Update(proj);

            item.Status = ePromoStatus.Done;
            Update(item);
        }

        private Task CreatePromoAsync(PromoProject proj)
        {
            var t = Task.Factory.StartNew(() => CreatePromo(proj));
            return t;
        }

        protected virtual void CreatePromo(PromoProject proj)
        {
            proj.OutputAvi = "abcd.avi";
        }
        private async void Step3_1_CreatingLowResVideo(PromoRequest item)
        {
            VideoAnalysisReport Analysis =
               (isAsync) ?
               await Get<VideoAnalysisReport>(item.Id, "api/ByRequestId/VideoAnalysisReport/")
               : Get<VideoAnalysisReport>(item.Id, "api/ByRequestId/VideoAnalysisReport/").Result;

            item.Status = ePromoStatus.CreatingLowResVideo;
            Update(item);

            Analysis.LowResVideoFile = "lowRes.Avi";
            Update(Analysis);
        }

        private async void Step2_1_DownloadingOriginalVideo(PromoRequest item)
        {

            item.Status = ePromoStatus.DownloadingOriginalVideo;
            Update(item);

            VideoAnalysisReport Analysis =
                (isAsync) ?
                await DownloadVideoAsync(item)
                : DownloadVideo(item);
            Analysis.OriginalVideo = "Orig.avi";

            Insert(Analysis);
            Update(item);

            //Thread.Sleep(20000);
            item.Status = ePromoStatus.DownloadedOriginalVideo;
            Update(item);

        }

        private async void Step1_GetYouTube(PromoRequest item)
        {
            var youtube =
                (isAsync) ?
                await GetYouTubeDetailsAsync(item)
                : GetYouTubeDetails(item);

            Insert(youtube);

            item.Status = ePromoStatus.GettingYouTubeDetails;

            Update(item);
        }

        protected virtual void AnalyzeScenes(VideoAnalysisReport Analysis)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("1,2000:Motion,Sound");
            sb.AppendLine("13,2000:Sound");
            sb.AppendLine("14,2000:Motion");
            sb.AppendLine("15,2000:=Sound");
            sb.AppendLine("16,2000:Motion,Sound, LargeDiff");

            Analysis.Scenes = sb.ToString();

        }

        private Task AnalyzeScenesAsync(VideoAnalysisReport report)
        {
            var t = Task.Factory.StartNew(() => AnalyzeScenes(report));
            return t;
        }

    }
}
