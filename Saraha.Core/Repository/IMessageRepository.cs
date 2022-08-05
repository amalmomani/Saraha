using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;

namespace Saraha.Core.Repository
{
    public interface IMessageRepository
    {
        public List<Message> getallMessage();
        public bool createMessage(Message message);
        public bool UpdateMessage(Message message);
        public bool deleteMessage(int? id);
    }
}
