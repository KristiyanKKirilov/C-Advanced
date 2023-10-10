using LogForU.Core.Enums;
using LogForU.Core.Exceptions;
using LogForU.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.Core.Models
{
    public class Message
    {
        private string createdTime;
        private string text;
        public Message(string createdTime, string text, ReportLevel reportLevel)
        {
            CreatedTime = createdTime;
            Text = text;
            ReportLevel = reportLevel;
        }
        public string CreatedTime 
        {
            get => createdTime;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyCreatedTimeException();
                }
                if (!DateTimeValidator.ValidatDateTime(value))
                {
                    throw new InvalidDateTimeException();
                }
                createdTime = value;
            }
        }
        public string Text 
        {
            get => text;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyMessageTextException();
                }

                text = value;
            }
        }
        public ReportLevel ReportLevel { get; private set; }
    }
}
