﻿using System;
using System.Threading.Tasks;

using DwFramework.Core;
using DwFramework.Core.Extensions;

namespace DwFramework.WebSocket.Extensions
{
    public static class WebSocketExtension
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="host"></param>
        public static void RegisterWebSocketService(this ServiceHost host)
        {
            host.RegisterType<WebSocketService>().SingleInstance();
        }

        /// <summary>
        /// 初始化服务
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="handler"></param>
        public static Task InitWebSocketServiceAsync(this IServiceProvider provider, OnConnectHandler onConnect = null, OnSendHandler onSend = null, OnReceiveHandler onReceive = null, OnCloseHandler onClose = null)
        {
            var service = provider.GetService<WebSocketService>();
            if (onConnect != null) service.OnConnect += onConnect;
            if (onSend != null) service.OnSend += onSend;
            if (onReceive != null) service.OnReceive += onReceive;
            if (onClose != null) service.OnClose += onClose;
            return service.OpenServiceAsync();
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static WebSocketService GetWebSocketService(this IServiceProvider provider)
        {
            return provider.GetService<WebSocketService>();
        }
    }
}
