//------------------------------------------------------------------------------
// <auto-generated>
//    Bu kod bir şablondan oluşturuldu.
//
//    Bu dosyada el ile yapılan değişiklikler uygulamanızda beklenmedik davranışa neden olabilir.
//    Kod yeniden oluşturulursa, bu dosyada el ile yapılan değişikliklerin üzerine yazılacak.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proje_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    
    public partial class hakkimizda
    {
        public int Id { get; set; }
        public string foto { get; set; }

        public virtual HttpPostedFileBase fotofile { get; set; }


        [Required]
        [Display(Name ="Başlık")]
        public string baslik { get; set; }

        [Required]
        [Display(Name = "Üst Başlık")]
        public string ustbaslik { get; set; }

        [AllowHtml]
        [Required]
        [Display(Name = "İçerik")]
        public string icerik { get; set; }
    }
}
