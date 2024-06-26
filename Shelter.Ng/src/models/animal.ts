import { AnimalStatus } from "../enum/animalStatus";

export class Animal {
    animalId : string = '';
    name : string = '';
    age : number = 0;
    breed : string = '';
    description : string = '';
    image: string | null = '';
    status: AnimalStatus = AnimalStatus.Available;
    

}

