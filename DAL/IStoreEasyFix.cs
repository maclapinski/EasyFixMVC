using System;
using EasyFixMVC.Models;
using System.Collections.Generic;

namespace EasyFixMVC.DAL{
    
    public interface IStoreEasyFix
    {
        FaultCode GetFaultCode(string wantedFaultCode);
        List<FaultCode> GetAllFaultCodes();
        List<Step> GetAllSteps();
        List<Comment> GetAllComments();
        void CreateFaultCode(FaultCode myNewFaultCode);
        void DeleteFaultCode(FaultCode faultCodeToDelete);
        void CreateStep(Step myNewStep);
        void CreateComment(Comment myNewComment);

    }
}
