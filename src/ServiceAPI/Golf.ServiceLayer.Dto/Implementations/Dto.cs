﻿using Golf.ServiceLayer.Dto.Interfaces;

namespace Golf.ServiceLayer.Dto.Implementations
{
    public abstract class BaseDto
    {
    }

    public abstract class Dto<T> : BaseDto, IDto<T>
    {
        public virtual T Id { get; set; }
    }
}
