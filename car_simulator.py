import urllib2
import requests
import time

time.sleep(10)


for i in range(0, 400):
	urllib2.urlopen("http://localhost:7171?carId=id&position="+str(i))
	if i == 110:
		data = dict(carId='newId', distance=150)
		requests.post("http://localhost:8989/car2car/app/createObject", data=data, allow_redirects=True)
	print("distance: " + str(i))
	time.sleep(0.05)
