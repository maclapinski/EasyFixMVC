using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EasyFixMVC.Models;
using EasyFixMVC.DAL;

namespace EasyFixMVC.Controllers
{


    public class EasyFixController : Controller
    {
        // List<FaultCode> _faultCodeList;
        //List<Step> _stepList;
        //List<Comment> _commentList;   

        IStoreEasyFix _faultCodeStorage;
        IStoreEasyFix _stepStorage;
        IStoreEasyFix _commentStorage;
   

        public EasyFixController(IStoreEasyFix faultCodeStorage, IStoreEasyFix stepStorage, IStoreEasyFix commentStorage ) //List<Step> stepList, List<Comment> commentList )
        {
            _faultCodeStorage = faultCodeStorage;
            _stepStorage = stepStorage;
            _commentStorage = commentStorage;
        }

        

        public IActionResult AllFaultcodes()
        {
            var allFaultCodes = _faultCodeStorage.GetAllFaultCodes();
            return View(allFaultCodes);
        }
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Dishwasher() 
        {
            var myCustomModel = new CustomModel();
            var allFaultCodes = _faultCodeStorage.GetAllFaultCodes();
            myCustomModel.FaultCodeList = allFaultCodes;
            // myCustomModel.StepList = _stepList;
            myCustomModel.Code = "";
            return View(myCustomModel);
        }

                public IActionResult DeleteFaultCode() 
        {
            var myCustomModel = new CustomModel();
            var allFaultCodes = _faultCodeStorage.GetAllFaultCodes();
            myCustomModel.FaultCodeList = allFaultCodes;
            // myCustomModel.StepList = _stepList;
            myCustomModel.Code = "";
            return View(myCustomModel);
        }

        [HttpPost]
        public IActionResult Dishwasher(CustomModel model) 
        {
            var allFaultCodes = _faultCodeStorage.GetAllFaultCodes();    
            model.FaultCodeList = allFaultCodes;
            // model.StepList = _stepList;
            //var targetCode = model.Code;

            //ViewBag.Editing = true;
            //var faultCode = GetByCode(id);
            return RedirectToAction("Details", model);
        }
        
        public IActionResult TroubleshootingView(CustomModel2 model)
        {        
            var allSteps = _stepStorage.GetAllSteps();                 
                // model.FaultCodeList = _faultCodeList;
                model.StepList = allSteps;    
            return View(model);
        }

        [HttpPost]
        public IActionResult Troubleshooting(CustomModel2 model) {
                
                var allSteps = _stepStorage.GetAllSteps();

                // model.FaultCodeList = _faultCodeList;
                model.StepList = allSteps;   
                model.StepNumber++;
                return RedirectToAction("TroubleshootingView", model);
        }

        
        [HttpPost]
        public IActionResult CreateComment(Comment newComment) {
                
            _commentStorage.CreateComment(newComment);    

            return RedirectToAction("Comment", newComment);
        }

          public IActionResult CreateComment(string Code) {
                
                return View();
        }

          public IActionResult Comment(Comment newComment)
        {

            return View(newComment);
        }

        public IActionResult Comments(string code) {
            var list = GetByCode(code);
            return View(list);
        }
        public IActionResult Create() {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(FaultCode myNewFaultCode)
        {
            
            _faultCodeStorage.CreateFaultCode(myNewFaultCode);
            return RedirectToAction("Index");
            // myNewFaultCode.Id = Guid.NewGuid();
            // _faultCodeStorage.Add(myNewFaultCode);
            // return RedirectToAction("Index");
        }

         [HttpPost]
        public IActionResult DeleteFaultCode(FaultCode faultCodeToDelete)
        {
            
            _faultCodeStorage.DeleteFaultCode(faultCodeToDelete);
            return RedirectToAction("AllFaultcodes");
            // myNewFaultCode.Id = Guid.NewGuid();
            // _faultCodeStorage.Add(myNewFaultCode);
            // return RedirectToAction("Index");
        }

        public IActionResult CreateStep() {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStep(Step myNewStep) {
            _stepStorage.CreateStep(myNewStep);
            return RedirectToAction("AllSteps");
        }

        public IActionResult AllSteps()
        {
            var allSteps = _stepStorage.GetAllSteps();
            return View(allSteps);
        }

        public IActionResult Find() {
            var myCustomModel = new CustomModel();
            
            var allFaultCodes = _faultCodeStorage.GetAllFaultCodes();    
            myCustomModel.FaultCodeList = allFaultCodes;
            // myCustomModel.StepList = _stepList;
            myCustomModel.Code = "";
            return View(myCustomModel);
        }

        [HttpPost]
        public IActionResult Find(CustomModel model) {
                var allFaultCodes = _faultCodeStorage.GetAllFaultCodes();    
                model.FaultCodeList = allFaultCodes;
                // model.StepList = _stepList;
                var targetCode = model.Code;

                //ViewBag.Editing = true;
                //var faultCode = GetByCode(id);
                return RedirectToAction("Details", model);
            }

        public IActionResult Details(CustomModel model) {
                var allFaultCodes = _faultCodeStorage.GetAllFaultCodes();    
                model.FaultCodeList = allFaultCodes;
                // model.StepList = _stepList;
                // var faultCode = GetByCode(id);
                return View(model);
            }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<Comment> GetByCode(string code) {
            
            var allComments = _commentStorage.GetAllComments();   

            var listOfComments = new List<Comment>();
            
            foreach (var comment in allComments) { 
                if (code == comment.Code)
                {
                    listOfComments.Add(comment);
                    
                }
 
            }

            if (listOfComments == null){
                throw new Exception("No comments found");
            }

            return listOfComments;
        }
    
    }
}
