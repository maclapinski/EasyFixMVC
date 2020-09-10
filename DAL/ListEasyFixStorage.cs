using System;
using EasyFixMVC.Models;
using System.Collections.Generic;

namespace EasyFixMVC.DAL
{
    public class ListEasyFixStorage : IStoreEasyFix
    
    {
        List<FaultCode> _faultCodeList;
        List<Step> _stepList;
        List<Comment> _commentList;

       public ListEasyFixStorage(List<FaultCode> faultCodeList, List<Step> stepList, List<Comment> commentList)
        {
           _faultCodeList = faultCodeList;
            _stepList = stepList;
            _commentList = commentList;
        }


       public FaultCode GetFaultCode(string wantedCode){
        
           foreach(var code in _faultCodeList)
            {
                if(wantedCode == code.Code)
                {
                   return code;
                }   
            }        
            throw new Exception("FaultCode not found");
        }

       public void DeleteFaultCode(FaultCode faultCodeToDelete)
        {
            _faultCodeList.Remove(faultCodeToDelete);
        }

        public void CreateFaultCode(FaultCode myNewFaultCode)
        {
            myNewFaultCode.Id = Guid.NewGuid();
            _faultCodeList.Add(myNewFaultCode);
        }

        public void CreateStep(Step myNewStep)
        {
            myNewStep.Id = Guid.NewGuid();
            _stepList.Add(myNewStep);
        }

        public void CreateComment(Comment myNewComment)
        {
            myNewComment.Id = Guid.NewGuid();
            _commentList.Add(myNewComment);
        }

       public List<FaultCode> GetAllFaultCodes()
        {
            return _faultCodeList;
        }

        public List<Step> GetAllSteps()
        {
            return _stepList;
        }
        public List<Comment> GetAllComments()
        {
            return _commentList;
        }
    }
}
