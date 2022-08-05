using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;

namespace Saraha.Core.Service
{
    public interface IMessageService
    {
        public List<Message> getallMessage();
        public bool createMessage(Message message);
        public bool UpdateMessage(Message message);
        public bool deleteMessage(int? id);
    }
}
