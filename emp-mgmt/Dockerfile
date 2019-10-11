# stage 1 for building the app
FROM node:latest as node
LABEL author="souvik"
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build:prod



# stage 2 for hosting it
FROM nginx:alpine
VOLUME /var/cache/nginx
COPY --from=node /app/dist/emp-mgmt /usr/share/nginx/html
COPY ./config/nginx.conf /etc/nginx/conf.d/default.conf
