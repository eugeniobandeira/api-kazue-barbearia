﻿using Kazue.Domain.Request.Service;

namespace Kazue.Domain.Interfaces.Infrastructure.Repository.Service;

public interface IUpdateServiceRepository
{
    Task Update(long id, ServiceRequest req);
}
