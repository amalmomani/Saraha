using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;

namespace Saraha.Core.Service
{
    public interface IMessageService
    {

        public List<Message> GetallMessage();
        public void CreateMessage(Message message);
        public void UpdateMessage(Message message);
        public void DeleteMessage(int? id);
    }
}
