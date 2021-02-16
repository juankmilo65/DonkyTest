using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DonkeyFilesBL.Interfaces;
using DonkeyFilesDAL.Context;
using DonkeyFilesDAL.Interface;
using DonkeyFilesDAL.Models;
using DonkeyFilesDAL.Repository;
using DonkeyFilesDML.DTO;


namespace DonkeyFilesBL.Files
{
    public class FilesDetailsBll : IFilesDetailsBll
    {
        private readonly IFileDetailsRepository repo;

        public FilesDetailsBll(FilesContext context)
        {
            repo = new FileDetailsRepository(context);
        }

        public async Task<IEnumerable<FillesDetailsDTO>> GetFileDetails()
        {
            IEnumerable<FillesDetailsDTO> files = new List<FillesDetailsDTO>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FileDetailsModel, FillesDetailsDTO>());
            var mapper = new Mapper(config);
            await Task.Run(() =>
            {
                files = mapper.Map<IEnumerable<FillesDetailsDTO>>(repo.GetFileDetails());
            });

            return files;
        }

        public async Task<FillesDetailsDTO> GetFileDetails(int id)
        {
            FillesDetailsDTO fileDetails = new FillesDetailsDTO();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FileDetailsModel, FillesDetailsDTO>());
            var mapper = new Mapper(config);

            await Task.Run(() =>
            {
                fileDetails = mapper.Map<FillesDetailsDTO>(repo.GetFileDetails(id));
            });

            return fileDetails;
        }

        public async Task<FillesDetailsDTO> PostFileDetails(FillesDetailsDTO fileDetailsInput)
        {
            FillesDetailsDTO fileDetails = new FillesDetailsDTO();
            var inputConfig = new MapperConfiguration(cfg => cfg.CreateMap<FillesDetailsDTO, FileDetailsModel>());
            var resultConfig = new MapperConfiguration(cfg => cfg.CreateMap<FileDetailsModel, FillesDetailsDTO>());
            var inputMapper = new Mapper(inputConfig);
            var resultMapper = new Mapper(resultConfig);

            await Task.Run(() =>
            {
                var dataObject = inputMapper.Map<FileDetailsModel>(fileDetailsInput);

                if (fileDetailsInput.File.Contains(","))
                {
                    fileDetailsInput.File = fileDetailsInput.File[(fileDetailsInput.File.IndexOf(",") + 1)..];
                }

                dataObject.DataFiles = Convert.FromBase64String(fileDetailsInput.File);

                fileDetails = resultMapper.Map<FillesDetailsDTO>(repo.PostFileDetails(dataObject));
            });

            return fileDetails;
        }

        public async Task<FillesDetailsDTO> PutFileDetails(int id, FillesDetailsDTO fileDetailsInput)
        {
            FillesDetailsDTO fileDetails = new FillesDetailsDTO();
            var inputConfig = new MapperConfiguration(cfg => cfg.CreateMap<FillesDetailsDTO, FileDetailsModel>());
            var resultConfig = new MapperConfiguration(cfg => cfg.CreateMap<FileDetailsModel, FillesDetailsDTO>());
            var inputMapper = new Mapper(inputConfig);
            var resultMapper = new Mapper(resultConfig);

            await Task.Run(() =>
            {
                fileDetails = resultMapper.Map<FillesDetailsDTO>(repo.PutFileDetails(id, inputMapper.Map<FileDetailsModel>(fileDetailsInput)));
            });

            return fileDetails;
        }

        public async Task<bool> FileDetailsExists(int id)
        {
            var result = false;
            await Task.Run(() =>
           {
               result = repo.FileDetailsExists(id);
           });

            return result;
        }

        public async Task<bool> DeleteFileDetails(int id)
        {
            var result = false;
            await Task.Run(() =>
            {
                result = repo.DeleteFileDetails(id);
            });

            return result;
        }

    }
}
