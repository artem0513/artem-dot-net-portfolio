﻿namespace DotNetExample.Dtos.Dtos
{
    public abstract class BaseDto<T>
    {
        public T? Id { get; set; }
    }
}
