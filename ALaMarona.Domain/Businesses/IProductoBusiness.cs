﻿using ALaMarona.Domain.Contracts;
using ALaMarona.Domain.Entities;
using ALaMarona.Domain.Generic;

namespace ALaMarona.Domain.Businesses
{
    public interface IProductoBusiness: IRestrictedUpdateBusiness<Producto, long, UpdateProductRequest>
    {
    }
}
