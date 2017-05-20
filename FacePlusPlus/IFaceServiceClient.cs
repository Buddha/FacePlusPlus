using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

///作者/Author——http://weibo.com/hupo376787
///发布修改时请遵循Mit协议/Please use Mit license while publish or modify

namespace FacePlusPlus
{
    public interface IFaceServiceClient
    {
        Task<Contract.Face[]> DetectFaceUrlAsync(string imageUrl, int return_landmark = 0, string return_attributes = "none");

        Task<Contract.Face[]> DetectFaceFileAsync(string imageFile, int return_landmark = 0, string return_attributes = "none");

        Task<Contract.Face[]> DetectFaceImageBase64Async(string imageBase64, int returnLandmarks = 0, string returnAttributes = "none");

        Task<Contract.CompareResult> CompareFaceTokenAsync(string faceToken1, string faceToken2);

        Task<Contract.CompareResult> CompareFaceUrlAsync(string imageUrl1, string imageUrl2);

        Task<Contract.CompareResult> CompareFaceFileAsync(string imageFile1, string imageFile2);

        Task<Contract.CompareResult> CompareFaceImageBase64Async(string imageBase641, string imageBase642);

        Task<Contract.SearchResult> SearchByTokenAsync(string faceToken, string faceTokenSet, int returnResultCount = 1);

        Task<Contract.SearchResult> SearchByUrlAsync(string imageUrl, string faceTokenSet, int returnResultCount = 1);

        Task<Contract.SearchResult> SearchByFileAsync(string imageFile, string faceTokenSet, int returnResultCount = 1);

        Task<Contract.SearchResult> SearchByImageBase64Async(string imageBase64, string faceTokenSet, int returnResultCount = 1);

        Task<Contract.AnalyzeResult> AnalyzeAsync(string faceTokens, int returnLandmark, string returnAttributes);

        Task<Contract.FaceDetail> GetDetailAsync(string faceToken);

        Task<Contract.SetUserIDResult> SetUserIdAsync(string faceToken, string userId);

        Task<Contract.FaceSetResult> FaceSetCreateAsync(string displayName = null, string outerId = null, string tagS = null, string faceTokens = null, string userData = null, int forceMerge = 0);

        Task<Contract.FaceSetResult> FaceSetAddFaceAsync(string facesetToken, string outerId, string faceTokens);

        Task<Contract.FaceSetResult> FaceSetRemoveFaceAsync(string facesetToken, string outerId, string faceTokens);

        Task<Contract.FaceSetResult> FaceSetUpdateAsync(string facesetToken, string outerId, string newOuterId, string displayName, string userData, string tagS);

        Task<Contract.FaceSetResult> FaceSetGetDetailAsync(string facesetToken, string outerId);

        Task<Contract.FaceSetResult> FaceSetDeleteAsync(string facesetToken, string outerId, int checkEmpty = 1);

        Task<Contract.FaceSetGetFaceSets> FaceSetGetFaceSetsAsync(string tagS = null, int startX = 1);

    }
}
