using Directions.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Directions.Dialogs
{
    [LuisModel(" a75e971f-baa9-4eda-9a28-df0ad72adf8c", "d2b2faad671a428f8572f80914c10538")]
    [Serializable]
    public class LUISDialog : LuisDialog<FindBusStation>
    {
        private Func<IForm<FindBusStation>> buildForm;

        public LUISDialog(Func<IForm<FindBusStation>> buildForm)
        {
            this.buildForm = buildForm;
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry I don't know what you mean.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            context.Call(new GreetingDialog(), Callback);
        }

        private  async Task Callback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }
        [LuisIntent("QueryBusStage")]
        public async Task QueryBusStage(IDialogContext context, LuisResult result)
        {
            foreach (var entity in result.Entities.Where(Entity => Entity.Type == "BusStation"))
            {
                var value = entity.Entity.ToLower();
                if (value == "Ngong" || value == "Kawangware" || value == "Yaya" || value == "Hurligham")
                {
                    await context.PostAsync("Yes we have that!");
                    context.Wait(MessageReceived);
                    return;
                }
                else
                {
                    await context.PostAsync("I'm sorry can't find that.");
                    context.Wait(MessageReceived);
                    return;
                }
            }
            await context.PostAsync("I'm sorry cant find that.");
            context.Wait(MessageReceived);
            return;
        }

    }
}