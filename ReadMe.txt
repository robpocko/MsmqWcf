See website 
	http://blogs.msdn.com/b/tomholl/archive/2008/07/12/msmq-wcf-and-iis-getting-them-to-play-nice-part-1.aspx 

	The article includes three parts, of which this is the first. Links to the 2nd and 3rd installments are in the website

	This describes how to a create a service using MSMQ bindings for WCF, that will be hosted in IIS

Steps taken to create this solution

1.	Created the MsmqContract project, which is just an ordinary Class Library project. Just leave it in default state for now.
	This project just will define the interface (contract) for the 'service'

	Note that when we come to define the interface we must decorate each operation that the msmq is to provide with IsOneWay=true

2.	Create the MsmqService project. This will be a WCF Service Application project. Just leave it in default state for now

3.	Create the MsmqClient project. This will be a Windows Forms Application project. Just leave it in defautl state for now

4.	In the contract project, 
		*	Add a reference to System.ComponentModel
		*	Rename Class1 to IMsmqContract. Change it from a class to an Interface, and add the method code.
			Remember that 
				*	The interface needs to be decorated with [ServiceContract]
				*	Each service method needs to be decorated with [OperationContract(IsOneWay = true)]

5.	In the service project,
		*	Add a reference to the Contract project
		*	Remove IService1.cs and Service1.svc
		*	Add new WCF Service item, called MsmqService.svc. This implements IMsmqContract. Delete the file IMsmqService. Add the appropriate code
		*	Open up Project Properties -> Web. Set the Servers dropdown to Local IIS, and then click 'Create Virtual Directory'

6.	Open up IIS Management Console
		*	On the 'Default Web Site' node, right-click, select 'Edit Bindings' and ensure that there is an entry for net.msmq, with Binding Information
			set to localhost
		*	Right-click the MsmqService application node, and select 'Manage Application -> Advanced settings...'. Update the 'Enabled Protocols' value
			to be		http,net.msmq

7.	Run Computer Management Console
		*	Services and Applications -> Message Queuing -> Private Queues (right-click) -> New -> Private Queue
		*	The name must be msmqservice/msmqservice.svc. Make sure that 'Transactional' is checked
		*	Right-click the new node and select Properties. On security tab, add new user. The user is MARBLE\IIS_IUSRS. Assign them 'Receive Message'
			i.e. check the allow box. Allow ticks should be automatically added for Peek Message and Send Message

8.	In the client project, add a reference to the contract project
		*	Add reference to System.ServiceModel
		*	Add MsmqContractClient class to project. This inherits from ClientBase<IMsmqContract> and implements IMsmqContract
		*	Need to config endpoints for client. Update app.config