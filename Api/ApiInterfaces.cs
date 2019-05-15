using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Projekt.Models;
using Refit;
using Xamarin.Forms;

namespace Projekt.Api
{
    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IPutUserInterface
    {
        [Put("/jsonapi/api/user")]
        Task<CheckStatus> PutUser([Body] UserModel usermodel, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IGetUserInterface
    {
        [Get("/jsonapi/api/user/?userid={userid}")]
        Task<UserModel> GetUser(int userid, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IGetUsersNearInterface
    {
        [Get("/jsonapi/api/usersnear/?userid={userid}")]
        Task<List<UserModel>> GetUsersNear(int userid, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IGetUsersInterface
    {
        [Get("/jsonapi/api/users/")]
        Task<List<UserModel>> GetUsers(UserModel usermodel, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IPostUserInterface
    {
        [Post("/jsonapi/api/user/")]
        Task<CheckStatus> PostUser([Body] UserModel usermodel, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IPasswordInterface
    {
        [Get("/jsonapi/api/passwordcheck/?username={username}&password={password}")]
        Task<CheckStatus> GetCheckPassword(string username, string password, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IGetUserCreatures
    {
        [Get("/jsonapi/api/userscreatures")]
        Task<List<Creaturesmodel>> GetUserCreaturesI(Creaturesmodel creaturesmodel, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IGetCreatureInfo
    {
        [Get("/jsonapi/api/creature")]
        Task<List<CreaturesInfo>> GetCreatureInfo(CreaturesInfo creaturesInfo, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IPutCreature
    {
        [Put("/jsonapi/api/creature")]
        Task<CheckStatus> PutUserCreatures([Body] Creaturesmodel creaturesmodel, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IPostCreature
    {
        [Post("/jsonapi/api/creature")]
        Task<CheckStatus> PostUserCreatures([Body] Creaturesmodel creaturesmodel, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IGetPrzedmioty
    {
        [Get("/jsonapi/api/przedmioty")]
        Task<List<Przedmiotymodel>> GetPrzedmiotymodel(Przedmiotymodel przedmiotymodel, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IGetPlecak
    {
        [Get("/jsonapi/api/plecak")]
        Task<List<Plecakmodel>> GetPlecakmodel(Plecakmodel plecakmodel, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json","Autorization: Basic")]
    internal interface IPostPlecak
    {
        [Post("/jsonapi/api/plecak")]
        Task<CheckStatus> PostPlecakmodel([Body] Plecakmodel plecakmodel, [Header("Authorization")] string authorization);
    }

    [Headers("Content-Type: application/json", "Autorization: Basic")]
    internal interface IGetServerTime
    {
        [Get("/jsonapi/api/time")]
        Task<Czasmodel> GetServerTime([Header("Authorization")] string authorization);
    }
}