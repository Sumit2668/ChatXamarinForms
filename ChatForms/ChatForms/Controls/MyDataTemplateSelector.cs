using ChatForms.CustomCell;
using ChatForms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChatForms.Controls
{
    public class MyDataTemplateSelector : DataTemplateSelector
    {

        private readonly DataTemplate incomingDataTemplate;
        private readonly DataTemplate outgoingDataTemplate;

        public MyDataTemplateSelector()
        {

            this.incomingDataTemplate = new DataTemplate(typeof(IncommingCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutGoingCell));

        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as Message;
            if (messageVm == null)
                return null;
            return messageVm.IsIncoming ? this.incomingDataTemplate : this.outgoingDataTemplate;
        }
    }
}
