# pull official base image
FROM node:20-alpine

# set working directory
WORKDIR /app

# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

# install app dependencies
COPY package.json ./
COPY yarn.lock ./

RUN yarn install

# add app
COPY . ./

# expose port 5173 for Vite dev server (default Vite port)
EXPOSE 5173

# start app with Vite
CMD ["yarn", "dev", "--host"]
