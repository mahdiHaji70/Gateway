export const MenuItems = [
    
    {
        label: 'Operation',
        url: 'assets/images/warehouse.png',
        items: [
            { label: 'Cargo Arrival', path: 'operation/cargo-arrival-list' },
            { label: 'Gate In', path: 'operation/gate-in-list' },
            { label: 'Gate Out', path: 'operation/gate-out-list' },
            { label: 'Weigh Bridge', path: 'operation/weigh-bridge-list' },
            { label: 'Discharge', path: 'operation/discharge-list' },
            { label: 'Operation Planning', path: 'operation/operation-planning-list' },
            { label: 'Operation Aggregation', path: 'operation/operation-aggregation-list' },
            { label: 'Change Package', path: 'operation/change-package' },
            { label: 'Stuff', path: 'operation/stuff' },
            { label: 'Store Receipt Request', path: 'operation/store-request' },           
            { label: 'Exit From Store', path: 'operation/exit-from-store-list' },

        ]
    },    
    {
        label: 'Document',
        icon: 'pi pi-file',
        items: [
            { label: 'Declaration', path: 'document/declaration-list' },
            { label: 'Store Receipt Issue', path: 'document/store-receipt-issue' },
        ]
    },
    {
        label: 'Basic Information',
        url: 'assets/images/basic-information-logo.png',
        icon: 'pi pi-pw pi-file',
        items: [
            { label: 'Commodity', path: 'commodity-list' },
            { label: 'Contact', path: 'contact-list' },
            { label: 'Country', path: 'country-list' },
            { label: 'City', path: 'city-list' },
            { label: 'Package', path: 'package-list' },
            { label: 'Traffic', path: 'traffic-list' },
            { label: 'Terminal', path: 'terminal-list' },
            { label: 'Declaration Type', path: 'declaration-type-list' },
            { label: 'Container', path: 'container-list' },
            { label: 'Container Type', path: 'container-type-list' },
            { label: 'Container Size', path: 'container-size-list' },
            { label: 'Vessel', path: 'vessel-list' },
            { label: 'Wagon', path: 'wagon-list' },
            { label: 'Truck', path: 'truck-list' },
            { label: 'Operation Type', path: 'operation-type-list' },
            { label: 'Place Type', path: 'place-type-list' },
            { label: 'Place', path: 'place-list' },
        ]
    }
    
];