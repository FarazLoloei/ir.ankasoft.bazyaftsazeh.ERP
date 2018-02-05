using ir.ankasoft.bazyaftsazeh.ERP.entities.Enums;
using System;
using System.Web.Mvc;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Dashboard
{
    public class ViewModelOperationsAttribute
    {
        [HiddenInput(DisplayValue = false)]
        public long recId { get; set; }

        public long StatusRecId { get; set; }

        public long OperationsAttributeTitleRefRecId { get; set; }

        public string OperationsAttributeTitle { get; set; }

        public string Value { get; set; }

        public DataType DataType { get; set; }

        public bool CheckBoxValue
        {
            get {
                if (DataType != DataType.Boolean) return false;
                Value = string.IsNullOrEmpty(Value) ? "false" : Value;

                return Boolean.Parse(Value); }
            set { Value = value.ToString(); }
        }
    }
}