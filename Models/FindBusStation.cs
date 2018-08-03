using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Directions.Models
{
    public enum KenkomStageOptions
    {
        Kawangware,
        Kibera,
        Hurligham,
        Yaya,
    }

    [Serializable]
    public class FindBusStation
    {
        public KenkomStageOptions? KenkomStage;
        public static IForm<FindBusStation> BuildForm()
        {
            return new FormBuilder<FindBusStation>()
                .Message("Welcome to the finding Bus Stages bot!")
                .Build();
        }
      
        


    }
}
    
    