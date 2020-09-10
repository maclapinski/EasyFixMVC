using System;
using System.Collections.Generic;
using EasyFixMVC.DAL;

namespace EasyFixMVC.Models
{
public class FaultCode
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        
    }

    public class CustomModel 
    {
       public List<FaultCode> FaultCodeList {get;set;}
       public string Brand { get; set; }
       public string Code {get;set;}
    }


}

