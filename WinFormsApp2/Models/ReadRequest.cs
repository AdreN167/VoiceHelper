﻿using System;

namespace VoiceHelper.Models
{
    class ReadRequest
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = "";
    }
}
