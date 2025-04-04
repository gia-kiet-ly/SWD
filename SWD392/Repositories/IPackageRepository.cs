﻿using SWD392.DB;
using SWD392.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPackageRepository
{
    Task<IEnumerable<Package>> GetAllPackagesAsync();
    Task<Package> GetPackageByIdAsync(int packageId);
    Task<Package> CreatePackageAsync(PackageDTO packageDto);
    Task<bool> UpdatePackageAsync(int packageId, PackageDTO packageDto);
    Task<bool> DeletePackageAsync(int packageId);

    Task<List<PackageSession>> GetAllPackageSessionsAsync();
    Task<List<PackageSession>> GetPackageSessionsByPackageIdAsync(int packageId);
    Task<bool> UpdatePackageSessionAsync(int packageId, PackageSessionDTO packageSessionDto);
    Task<List<PackageWithDoctorDTO>> GetAllPackagesWithDoctorAsync();

}
