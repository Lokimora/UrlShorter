using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShorter.Models.DB
{
    public class Reduction
    {
        public long ID { get; set; }

        public DateTime CreateDate { get; set; }

        public string OriginalUrl { get; set; }

        /// <summary>
        /// Рандомная строка, которая связывается с полным url'om и прибавляется к базовому пути: {baseUrl}/{shortRelUrl}
        /// </summary>
        public string ShortRelUrl { get; set; }

        public int PassageCount { get; set; }


    }
}