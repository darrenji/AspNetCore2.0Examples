using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Services
{
    public class MessageService : IMessageService
    {
        private readonly MessageOptions options;

        public MessageService(MessageOptions options)
        {
            this.options = options;
        }
        public string FormatMessage(string message)
        {
            return this.options.Format == MessageFormat.None ? message :
                this.options.Format == MessageFormat.Upper ? message.ToUpper() :
                message.ToLower();
        }
    }

    public enum MessageFormat { None, Upper, Lower}

    public class MessageOptions
    {
        public MessageFormat Format { get; set; } 
    }
}
