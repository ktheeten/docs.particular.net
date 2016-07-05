#### Version 5 and below

Normally workers are deployed to different machines. When deployed to the same machine a GUID will be added to the end of the worker input queue name. This allows the distributor to properly route messages and prevents workers from competing on the same queue. Since, in this project, "different machines" are being faked by using different projects, the GUID behavior is overridden to prevent a proliferation of queue names.