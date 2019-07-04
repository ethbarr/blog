FROM nginx

EXPOSE 443
EXPOSE 80

COPY ./localhost.crt /etc/nginx
COPY ./localhost.key /etc/nginx
COPY ./nginx-proxy/nginx.conf /etc/nginx

CMD ["nginx", "-g", "daemon off;"]
