# Note
//Access Hadoop UI from Browser
http://localhost:9870/
//create a new bridge type network
docker network create --driver=bridge --subnet=192.168.1.0/24 eth0
//run 2 new machines with static ip
docker run -it -p 9870:9870 --net eth0 --ip 192.168.1.30 -h ngan-master --name ngan-master master:20.04
docker run -it --net eth0 --ip 192.168.1.31 -h hung-slave --name hung-slave slave1:20.04