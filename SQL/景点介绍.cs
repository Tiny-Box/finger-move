//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class 景点介绍
    {
        public string 序号 { get; set; }
        public string 名称 { get; set; }
        public string 地址 { get; set; }
        public string 门票 { get; set; }
        public string 开放时间 { get; set; }
        public string 简介 { get; set; }
    
        public virtual fare fare { get; set; }
        public virtual number number { get; set; }
        public virtual times times { get; set; }
        public virtual type type { get; set; }
    }
}
