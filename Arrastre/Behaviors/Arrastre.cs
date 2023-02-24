using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System.Linq;

namespace Arrastre.Behaviors
{
    public class Arrastre : Behavior<View>
    {
        public double Verticaltransation { get; set; }
        PanGestureRecognizer panGestureRecognizer = new PanGestureRecognizer();
        protected override void OnAttachedTo(View bindable)
        {
            panGestureRecognizer.PanUpdated += PanGestureRecognizer_PanUpdated;
            bindable.GestureRecognizers.Add(panGestureRecognizer);
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(View bindable)
        {
            panGestureRecognizer.PanUpdated -= PanGestureRecognizer_PanUpdated;
            bindable.GestureRecognizers.Remove(panGestureRecognizer);
            base.OnDetachingFrom(bindable);
        }
        private async void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    if (e.TotalY > 0)
                    {
                        await ((View)sender).TranslateTo(0, e.TotalY);
                        Verticaltransation = e.TotalY;
                    }
                    break;
                case GestureStatus.Completed:
                    if (Verticaltransation > 100)
                    {
                        await ((View)sender).TranslateTo(0, 200);
                        if (PopupNavigation.Instance.PopupStack.Any())
                        {
                            await PopupNavigation.Instance.PopAsync();
                        }
                    }
                    else
                    {
                        await ((View)sender).TranslateTo(0, e.TotalY);
                    }
                    break;
            }
        }
    }
}
