These are the tokens I have used using SecretManager
For the web application to work, you must put the following below in the
secrets.json file 
This can be done in Solution Explorer
Right click WebAppProj
Manage User Secrets
secrets.json should open and the following below should copied into it.  

"Authentication:Google:ClientId": "728840530883-sq0ml8ru79p0ouf4ah8b44au77hm5hu2.apps.googleusercontent.com",
"Authentication:Google:ClientSecret": "5KWl-Vt4UnsLSXZbuQEpyfva"

After doing this, the application should work accordingly.