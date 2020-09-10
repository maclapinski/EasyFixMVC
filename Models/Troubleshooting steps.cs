using System;
using System.Collections.Generic;

namespace EasyFixMVC.Models
{

public class CustomModel2 {
        public List<Step> StepList {get;set;}  
        public string Code {get;set;}
        public int StepNumber { get; set; }
    }
public class Step
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Code { get; set; }
        public string StepDescription { get; set; }

    }
}