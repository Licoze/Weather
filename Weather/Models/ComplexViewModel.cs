using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Weather.Models
{
    //Немного громоздкое решение чтобы заюзать встроенные возможности
    //валидации(а они как я понял только для строго-типизированных представлений) фреймворка.
    //Как альтернативу можно попробовать ajax или сделать валидацию вручную на JSe, надо смотреть.
    public class ComplexViewModel
    {
        public SearchFormViewModel Form { get; set; }
        public ForecastViewModel Result { get; set; }

    }
}