//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManager.DAC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public int Task_ID { get; set; }
        public Nullable<int> Parent_Task_ID { get; set; }
        public Nullable<int> Project_ID { get; set; }
        public string Task_Name { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<int> Priority { get; set; }
        public int Status { get; set; }
    }
}
