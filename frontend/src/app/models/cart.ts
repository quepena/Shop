import { v4 as uuid } from 'uuid';

export interface ICartItem {
    id: number;
    productName: string;
    price: number;
    quantity: number;
    image: string;
    category: string;
    brand: string;
}

export interface ICart {
    id: string;
    items: ICartItem[];
}

export class Cart implements ICart {
    id = uuid();
    items: ICartItem[] = [];
}