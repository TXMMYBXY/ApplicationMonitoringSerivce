# =========================
# Стадия сборки фронта
# =========================
FROM node:22-alpine AS build
WORKDIR /app

# Копируем package.json и т.п.
COPY package*.json ./
RUN npm install

# Копируем остальной код
COPY . .

# Аргумент/переменная окружения для Vite
ARG VITE_API_URL
ENV VITE_API_URL=${VITE_API_URL}

# Собираем продовый бандл
RUN echo "VITE_API_URL at build: ${VITE_API_URL}"
RUN npm run build

# =========================
# Стадия рантайма (nginx)
# =========================
FROM nginx:alpine AS final

# Копируем собранный фронт в стандартную директорию nginx
COPY --from=build /app/dist /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]