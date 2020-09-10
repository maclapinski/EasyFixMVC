using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using EasyFixMVC.Models;

namespace EasyFixMVC.DAL {
    public class EFEasyFixStorage : IStoreEasyFix {
        
        //private member
        EasyFixContext _FaultCodesContext;
        EasyFixContext _StepsContext;

        EasyFixContext _CommentsContext;


        public EFEasyFixStorage(EasyFixContext FaultCodesContext, EasyFixContext StepsContext, EasyFixContext CommentsContext) 
        
        {
            _FaultCodesContext = FaultCodesContext;
            _StepsContext = StepsContext;
            _CommentsContext = CommentsContext;
        }

        public FaultCode GetFaultCode(string wantedCode) {
            var faultCode = _FaultCodesContext.FaultCodes.FirstOrDefault(x => x.Code == wantedCode);
            return faultCode;
        }

        public void CreateFaultCode(FaultCode myNewFaultCode)
        {
            myNewFaultCode.Id = Guid.NewGuid();
            _FaultCodesContext.Add(myNewFaultCode);
            _FaultCodesContext.SaveChanges();

        }
        public void DeleteFaultCode(FaultCode faultCodeToDelete)
        {
            _FaultCodesContext.Remove(faultCodeToDelete);
            _FaultCodesContext.SaveChanges();

        }

        public void CreateStep(Step myNewStep)
        {
            myNewStep.Id = Guid.NewGuid();
            _StepsContext.Add(myNewStep);
            _StepsContext.SaveChanges();

        }

        public void CreateComment(Comment myNewComment)
        {
            myNewComment.Id = Guid.NewGuid();
            _CommentsContext.Add(myNewComment);
            _CommentsContext.SaveChanges();

        }

       public List<FaultCode> GetAllFaultCodes()
        {
            var allFaultCodes = _FaultCodesContext.FaultCodes
            .ToList();
            return allFaultCodes;
        }

        public List<Step> GetAllSteps()
        {
            var allSteps = _StepsContext.Steps
            .ToList();
            return allSteps;
        }
        public List<Comment> GetAllComments()
        {
            var allComments = _CommentsContext.Comments
            .ToList();
            return allComments;
        }

    }

}