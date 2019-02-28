export class StoreItem {
    constructor(
        public id: number,
        public productId: number,
        public hiveSectionId: number,
        public quantity: number,
        public isConfirmed: boolean
    ) { }
}