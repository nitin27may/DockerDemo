# Docker Demo (Dontnet Razor)
This is a small project using .net Razor to display running container's id and IP addreess with Enviornment variable.

ENV AppName

This is just to learn/check scenarios:
1. when we are running multiple instance of containers from same images and using load balancer 
2. Create multiple application using same image, jsut pass AppName as variable while creating new container

Run Command

```
docker run -d --name MyFirstApplication -e AppName=Application1 -p 80:80 -it  nitin27may/dockerdemo
```

Just change exposed port and AppName value for running multiuple instances.