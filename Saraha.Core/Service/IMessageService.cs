﻿using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;
using Saraha.Core.DTO;

namespace Saraha.Core.Service
{
    public interface IMessageService
    {

        public List<Message> GetallMessage();
        public void CreateMessage(Message message, int userLoggedId);
        public void UpdateMessage(Message message);
        public void DeleteMessage(int? id);
        public List<UserMessage> GetUserMessage();
        public List<UserMessage> GetUserMessageById(int userId);
        public List<Message> GetUserMessageByIdcount(int userId);


    }
}
