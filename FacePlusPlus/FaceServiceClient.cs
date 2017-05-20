using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;

///作者/Author——http://weibo.com/hupo376787
///发布修改时请遵循Mit协议/Please use Mit license while publish or modify

namespace FacePlusPlus
{
    public class FaceServiceClient : IDisposable, IFaceServiceClient
    {
        private string _api_key = "";
        private string _api_secret = "";
        private string _detect_api_url = "https://api-cn.faceplusplus.com/facepp/v3/detect";
        private string _compare_api_url = "https://api-cn.faceplusplus.com/facepp/v3/compare";
        private string _search_api_url = "https://api-cn.faceplusplus.com/facepp/v3/search";
        private string _analyze_api_url = "https://api-cn.faceplusplus.com/facepp/v3/face/analyze";
        private string _getdetail_api_url = "https://api-cn.faceplusplus.com/facepp/v3/face/getdetail";
        private string _setuserid_api_url = "https://api-cn.faceplusplus.com/facepp/v3/face/setuserid";
        private string _faceset_create_api_url = "https://api-cn.faceplusplus.com/facepp/v3/faceset/create";
        private string _faceset_addface_api_url = "https://api-cn.faceplusplus.com/facepp/v3/faceset/addface";
        private string _faceset_removeface_api_url = "https://api-cn.faceplusplus.com/facepp/v3/faceset/removeface";
        private string _faceset_update_api_url = "https://api-cn.faceplusplus.com/facepp/v3/faceset/update";
        private string _faceset_getdetail_api_url = "https://api-cn.faceplusplus.com/facepp/v3/faceset/getdetail";
        private string _faceset_delete_api_url = "https://api-cn.faceplusplus.com/facepp/v3/faceset/delete";
        private string _faceset_getfacesets_api_url = "https://api-cn.faceplusplus.com/facepp/v3/faceset/getfacesets";


        public FaceServiceClient(string api_key, string api_secret)
        {
            this._api_key = api_key;
            this._api_secret = api_secret;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        ~FaceServiceClient()
        {
            this.Dispose(false);
        }

        //Post File not supported now.
        private async Task<string> SendRequestAsync(string apiUrl, object obj)
        {
            string res = "";
            try
            {
                res = await apiUrl
                       .PostMultipartAsync(mp => mp
                       .AddStringParts(obj)
                       ).ReceiveString();
            }
            catch (FlurlHttpTimeoutException)
            {
                return "FlurlHttp internal time out.";
            }
            catch (FlurlHttpException ex)
            {
                return ex.Call.ErrorResponseBody;
                //if (ex.Call.Response != null)
                //    return "Failed with response code " + ex.Call.Response.StatusCode;
                //else
                //    return "Totally failed before getting a response! " + ex.Message;
            }

            return res;
        }

        public async Task<Contract.Face[]> DetectFaceUrlAsync(string imageUrl, int returnLandmarks = 0, string returnAttributes = "none")
        {
            Contract.DetectResult dr = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, image_url = imageUrl, return_landmark = returnLandmarks, return_attributes = returnAttributes };
            var res = await SendRequestAsync(_detect_api_url, obj);
            dr = JsonConvert.DeserializeObject<Contract.DetectResult>(res);

            return dr.faces;
        }

        public async Task<Contract.Face[]> DetectFaceFileAsync(string imageFile, int returnLandmarks = 0, string returnAttributes = "none")
        {
            Contract.DetectResult dr = null;
            string res = "";
            try
            {
                res = await _detect_api_url
                       .PostMultipartAsync(mp => mp
                       .AddStringParts(new { api_key = _api_key, api_secret = _api_secret, return_landmark = returnLandmarks, return_attributes = returnAttributes })
                       .AddFile("image_file", imageFile)
                       ).ReceiveString();
            }
            catch (FlurlHttpTimeoutException)
            {
                res = "FlurlHttp internal time out.";
            }
            catch (FlurlHttpException ex)
            {
                res = ex.Call.ErrorResponseBody;
            }
            dr = JsonConvert.DeserializeObject<Contract.DetectResult>(res);

            return dr.faces;
        }

        public async Task<Contract.Face[]> DetectFaceImageBase64Async(string imageBase64, int returnLandmarks = 0, string returnAttributes = "none")
        {
            Contract.DetectResult dr = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, image_base64 = imageBase64, return_landmark = returnLandmarks, return_attributes = returnAttributes };
            var res = await SendRequestAsync(_detect_api_url, obj);
            dr = JsonConvert.DeserializeObject<Contract.DetectResult>(res);

            return dr.faces;
        }

        public async Task<Contract.CompareResult> CompareFaceTokenAsync(string faceToken1, string faceToken2)
        {
            Contract.CompareResult cr = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, face_token1 = faceToken1, face_token2 = faceToken2 };
            var res = await SendRequestAsync(_compare_api_url, obj);
            cr = JsonConvert.DeserializeObject<Contract.CompareResult>(res);

            return cr;
        }

        public async Task<Contract.CompareResult> CompareFaceUrlAsync(string imageUrl1, string imageUrl2)
        {
            Contract.CompareResult cr = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, image_url1 = imageUrl1, image_url2 = imageUrl2 };
            var res = await SendRequestAsync(_compare_api_url, obj);
            cr = JsonConvert.DeserializeObject<Contract.CompareResult>(res);

            return cr;
        }

        public async Task<Contract.CompareResult> CompareFaceFileAsync(string imageFile1, string imageFile2)
        {
            Contract.CompareResult cr = null;
            string res = "";
            try
            {
                res = await _compare_api_url
                       .PostMultipartAsync(mp => mp
                       .AddStringParts(new { api_key = _api_key, api_secret = _api_secret })
                       .AddFile("image_file1", imageFile1)
                       .AddFile("image_file2", imageFile2)
                       ).ReceiveString();
            }
            catch (FlurlHttpTimeoutException)
            {
                res = "FlurlHttp internal time out.";
            }
            catch (FlurlHttpException ex)
            {
                res = ex.Call.ErrorResponseBody;
            }
            cr = JsonConvert.DeserializeObject<Contract.CompareResult>(res);

            return cr;
        }

        public async Task<Contract.CompareResult> CompareFaceImageBase64Async(string imageBase641, string imageBase642)
        {
            Contract.CompareResult cr = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, image_base64_1 = imageBase641, image_base64_2 = imageBase642 };
            var res = await SendRequestAsync(_compare_api_url, obj);
            cr = JsonConvert.DeserializeObject<Contract.CompareResult>(res);

            return cr;
        }

        public async Task<Contract.SearchResult> SearchByTokenAsync(string faceToken, string faceTokenSet, int returnResultCount = 1)
        {
            Contract.SearchResult sr = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, face_token = faceToken, faceset_token = faceTokenSet };
            var res = await SendRequestAsync(_search_api_url, obj);
            sr = JsonConvert.DeserializeObject<Contract.SearchResult>(res);

            return sr;
        }

        public async Task<Contract.SearchResult> SearchByUrlAsync(string imageUrl, string faceTokenSet, int returnResultCount = 1)
        {
            Contract.SearchResult sr = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, image_url = imageUrl, faceset_token = faceTokenSet };
            var res = await SendRequestAsync(_search_api_url, obj);
            sr = JsonConvert.DeserializeObject<Contract.SearchResult>(res);

            return sr;
        }

        public async Task<Contract.SearchResult> SearchByFileAsync(string imageFile, string faceTokenSet, int returnResultCount = 1)
        {
            Contract.SearchResult sr = null;
            string res = "";
            try
            {
                res = await _search_api_url
                       .PostMultipartAsync(mp => mp
                       .AddStringParts(new { api_key = _api_key, api_secret = _api_secret, faceset_token = faceTokenSet })
                       .AddFile("image_file", imageFile)
                       ).ReceiveString();
            }
            catch (FlurlHttpTimeoutException)
            {
                res = "FlurlHttp internal time out.";
            }
            catch (FlurlHttpException ex)
            {
                res = ex.Call.ErrorResponseBody;
            }
            sr = JsonConvert.DeserializeObject<Contract.SearchResult>(res);

            return sr;
        }

        public async Task<Contract.SearchResult> SearchByImageBase64Async(string imageBase64, string faceTokenSet, int returnResultCount = 1)
        {
            Contract.SearchResult sr = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, image_base64 = imageBase64, faceset_token = faceTokenSet };
            var res = await SendRequestAsync(_search_api_url, obj);
            sr = JsonConvert.DeserializeObject<Contract.SearchResult>(res);

            return sr;
        }

        public async Task<Contract.AnalyzeResult> AnalyzeAsync(string faceTokens, int returnLandmark, string returnAttributes)
        {
            Contract.AnalyzeResult ar = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, face_tokens = faceTokens, return_landmark = returnLandmark, return_attributes = returnAttributes };
            var res = await SendRequestAsync(_analyze_api_url, obj);
            ar = JsonConvert.DeserializeObject<Contract.AnalyzeResult>(res);

            return ar;
        }

        public async Task<Contract.FaceDetail> GetDetailAsync(string faceToken)
        {
            Contract.FaceDetail fd = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, face_token = faceToken };
            var res = await SendRequestAsync(_getdetail_api_url, obj);
            fd = JsonConvert.DeserializeObject<Contract.FaceDetail>(res);

            return fd;
        }

        public async Task<Contract.SetUserIDResult> SetUserIdAsync(string faceToken, string userId)
        {
            Contract.SetUserIDResult su = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, face_token = faceToken, user_id = userId };
            var res = await SendRequestAsync(_setuserid_api_url, obj);
            su = JsonConvert.DeserializeObject<Contract.SetUserIDResult>(res);

            return su;
        }

        public async Task<Contract.FaceSetResult> FaceSetCreateAsync(string displayName = null, string outerId = null, string tagS = null, string faceTokens = null, string userData = null, int forceMerge = 0)
        {
            Contract.FaceSetResult fs = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, display_name = displayName, outer_id = outerId, tags = tagS, face_tokens = faceTokens, user_data = userData, force_merge = forceMerge };
            var res = await SendRequestAsync(_faceset_create_api_url, obj);
            fs = JsonConvert.DeserializeObject<Contract.FaceSetResult>(res);

            return fs;
        }

        public async Task<Contract.FaceSetResult> FaceSetAddFaceAsync(string facesetToken, string outerId, string faceTokens)
        {
            Contract.FaceSetResult fs = null;
            if (facesetToken != null)
            {
                var obj = new { api_key = _api_key, api_secret = _api_secret, faceset_token = facesetToken, face_tokens = faceTokens };
                var res = await SendRequestAsync(_faceset_addface_api_url, obj);
                fs = JsonConvert.DeserializeObject<Contract.FaceSetResult>(res);
            }
            if (outerId != null)
            {
                var obj = new { api_key = _api_key, api_secret = _api_secret, outer_id = outerId, face_tokens = faceTokens };
                var res = await SendRequestAsync(_faceset_addface_api_url, obj);
                fs = JsonConvert.DeserializeObject<Contract.FaceSetResult>(res);
            }

            return fs;
        }


        public async Task<Contract.FaceSetResult> FaceSetRemoveFaceAsync(string facesetToken, string outerId, string faceTokens)
        {
            Contract.FaceSetResult fs = null;
            if (facesetToken != null)
            {
                var obj = new { api_key = _api_key, api_secret = _api_secret, faceset_token = facesetToken, face_tokens = faceTokens };
                var res = await SendRequestAsync(_faceset_removeface_api_url, obj);
                fs = JsonConvert.DeserializeObject<Contract.FaceSetResult>(res);
            }
            if (outerId != null)
            {
                var obj = new { api_key = _api_key, api_secret = _api_secret, outer_id = outerId, face_tokens = faceTokens };
                var res = await SendRequestAsync(_faceset_removeface_api_url, obj);
                fs = JsonConvert.DeserializeObject<Contract.FaceSetResult>(res);
            }
            
            return fs;
        }

        public async Task<Contract.FaceSetResult> FaceSetUpdateAsync(string facesetToken, string outerId, string newOuterId, string displayName, string userData, string tagS)
        {
            Contract.FaceSetResult fs = null;
            if (facesetToken != null)
            {
                var obj = new { api_key = _api_key, api_secret = _api_secret, faceset_token = facesetToken, new_outer_id = newOuterId, display_name = displayName, user_data = userData, tagS = tagS };
                var res = await SendRequestAsync(_faceset_update_api_url, obj);
                fs = JsonConvert.DeserializeObject<Contract.FaceSetResult>(res);
            }
            if (outerId != null)
            {
                var obj = new { api_key = _api_key, api_secret = _api_secret, outer_id = outerId, new_outer_id = newOuterId, display_name = displayName, user_data = userData, tagS = tagS };
                var res = await SendRequestAsync(_faceset_update_api_url, obj);
                fs = JsonConvert.DeserializeObject<Contract.FaceSetResult>(res);
            }

            return fs;
        }

        public async Task<Contract.FaceSetResult> FaceSetGetDetailAsync(string facesetToken, string outerId)
        {
            Contract.FaceSetResult fs = null;
            if (facesetToken != null)
            {
                var obj = new { api_key = _api_key, api_secret = _api_secret, faceset_token = facesetToken};
                var res = await SendRequestAsync(_faceset_getdetail_api_url, obj);
                fs = JsonConvert.DeserializeObject<Contract.FaceSetResult>(res);
            }
            if (outerId != null)
            {
                var obj = new { api_key = _api_key, api_secret = _api_secret, outer_id = outerId};
                var res = await SendRequestAsync(_faceset_getdetail_api_url, obj);
                fs = JsonConvert.DeserializeObject<Contract.FaceSetResult>(res);
            }

            return fs;
        }

        public async Task<Contract.FaceSetResult> FaceSetDeleteAsync(string facesetToken, string outerId, int checkEmpty = 1)
        {
            Contract.FaceSetResult fs = null;
            if (facesetToken != null)
            {
                var obj = new { api_key = _api_key, api_secret = _api_secret, faceset_token = facesetToken, check_empty = checkEmpty };
                var res = await SendRequestAsync(_faceset_delete_api_url, obj);
                fs = JsonConvert.DeserializeObject<Contract.FaceSetResult>(res);
            }
            if (outerId != null)
            {
                var obj = new { api_key = _api_key, api_secret = _api_secret, outer_id = outerId, check_empty = checkEmpty };
                var res = await SendRequestAsync(_faceset_delete_api_url, obj);
                fs = JsonConvert.DeserializeObject<Contract.FaceSetResult>(res);
            }

            return fs;
        }

        public async Task<Contract.FaceSetGetFaceSets> FaceSetGetFaceSetsAsync(string tagS = null, int startX = 1)
        {
            Contract.FaceSetGetFaceSets fs = null;
            var obj = new { api_key = _api_key, api_secret = _api_secret, tags = tagS, start = startX };
            var res = await SendRequestAsync(_faceset_getfacesets_api_url, obj);
            fs = JsonConvert.DeserializeObject<Contract.FaceSetGetFaceSets>(res);

            return fs;
        }

    }
}
