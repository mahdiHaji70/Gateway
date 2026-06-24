
export class ApiEndpoints {

  //public static readonly BASE_URL = 'http://localhost:5201/api';
  public static readonly BASE_URL = 'https://localhost:7032/api';
  public static readonly BASE_AUTH_URL = 'https://localhost:7202/api/Auth';


  public static readonly Traffic = `${this.BASE_URL}/Traffic`;
  public static readonly Traffic_GET_ALL = `${this.BASE_URL}/Traffic/GetAll`;

  public static readonly Declarations = `${this.BASE_URL}/Declarations`;
  public static readonly Request_Ipas_Declaration_Id = `${this.BASE_URL}/Declarations/request-ipas-declaration-id`;
  public static readonly Request_Ipas_Declaration_Items = `${this.BASE_URL}/DeclarationItems/request-ipas-declaration-items`;
  public static readonly Declaration_Item = `${this.BASE_URL}/DeclarationItem`;
  public static readonly Declaration_Container = `${this.BASE_URL}/DeclarationContainer`;
  public static readonly Get_Declaration_Items_By_Declaration_Id = `${this.BASE_URL}/declarationItems/get_by_declaration_id`;
  public static readonly Get_Declaration_Container_By_Declaration_Item_Id = `${this.BASE_URL}/DeclarationContainer/GetByDeclarationItem`;
  public static readonly Declaration_Container_Info = `${this.BASE_URL}/DeclarationContainerInfo`;
  public static readonly Get_Declaration_Container_Info_By_Declaration_Container_Id = `${this.BASE_URL}/DeclarationContainerInfo/GetByDeclarationContainer`;

  public static readonly Gate = `${this.BASE_URL}/GateEvent`;  
  public static readonly Get_Vehicles_By_Type = `${this.BASE_URL}/Vehicle/GetByVehicleType`;

  public static readonly Weight_Bridge = `${this.BASE_URL}/WeightBridge`;  
  public static readonly Operation_Detail = `${this.BASE_URL}/OperationDetail`;  
  public static readonly Operation_Planning = `${this.BASE_URL}/OperationPlanning`;  
  public static readonly Cargo_Arrival_Declaration = `${this.BASE_URL}/CargoArrivalDeclaration`;    
  public static readonly Operation_Aggregation = `${this.BASE_URL}/OperationAggregation`;    
  public static readonly Store_Receipt_Request = `${this.BASE_URL}/StoreReceiptRequest`;    
  public static readonly Store_Receipt = `${this.BASE_URL}/StoreReceipt`;    
  public static readonly Stuff = `${this.BASE_URL}/Stuff`;    
  

}
 