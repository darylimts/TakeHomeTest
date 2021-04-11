## Running the sample using Docker

You can run the Web sample by running these commands from the root folder (where the .sln file is located):

```
docker-compose build
docker-compose up
```

You should be able to make requests to localhost:5106 for the Web project, and localhost:5200 for the Public API project once these commands complete. If you have any problems, especially with login, try from a new guest or incognito browser instance.

You can also run the applications by using the instructions located in their `Dockerfile` file in the root of each project. Again, run these commands from the root of the solution (where the .sln file is located).


you can change the OS settings TakeHomeTest.UI.Web.csproj & TakeHomeTest.Hosts.Web.csproj
    <DockerDefaultTargetOS>Windows</DockerDefaultTargetOS>
    <DockerDefaultTargetOS>Linux</DockerDefaultTargetOS>


## Web GUI
1. First, you can key in a parameter for the Clock Decrement Value which in Seconds.
2. The Validation for the TextBox included Not Allow Empty Text, Not allow to key in alphabet, only Range from (1-60) is acceptable.
3. After you press Enter, you will see StartTimer Button is appear & Clock Decrement TextBox become disable.
4. When you press StartTimer Button, The StartTimer Button will become StopTImer & Timer is running. Time will decrease every second.
5. When you press StopTimer Button, timer will be stopped & you may repeat from Step 1.