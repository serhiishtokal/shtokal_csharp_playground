﻿namespace AspNetPlayground.Domain;

public interface IMessage
{
   public string Content { get; }
   public string ToPhoneNumber { get; }
}