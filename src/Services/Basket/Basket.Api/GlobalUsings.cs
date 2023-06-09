﻿global using Microsoft.OpenApi.Models;
global using Basket.Api;
global using Basket.Api.Entities;
global using Basket.Api.Interfaces;
global using Microsoft.Extensions.Caching.Distributed;
global using System.Text.Json;
global using AutoMapper;
global using Microsoft.AspNetCore.Mvc;
global using System.Net;
global using Basket.Api.ViewModels;
global using Basket.Api.InputModels;
global using Basket.Api.Repositories;
global using Discount.Grpc.Protos;
global using Basket.Api.GrpcServices;
global using Basket.Api.Services;
global using EventBus.Messages.Events;
global using MassTransit;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
