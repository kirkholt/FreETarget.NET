import { aTarget } from "./aTarget";
import { TargetType } from "./TargetType";

export class Rifle50m extends aTarget {
    private pelletCaliber: number;
    private targetSize: number = 250; //mm
    private rifleBlackRings: number = 4;
    private solidInnerTenRing: boolean = false;


    private outterRing: number = 154.4; //mm
    private ring2: number = 138.4; //mm
    private ring3: number = 122.4; //mm
    private ring4: number = 106.4; //mm
    private ring5: number = 90.4; //mm
    private ring6: number = 74.4; //mm
    private ring7: number = 58.4; //mm
    private ring8: number = 42.4; //mm
    private ring9: number = 26.4; //mm
    private ring10: number = 10.4; //mm
    private innerRing: number = 5.0; //mm

    private blackCircle: number = 112.4; //mm

    private innerTenRadiusRifle: number;

    private ringsRifle: number[] = [
        this.outterRing,
        this.ring2,
        this.ring3,
        this.ring4,
        this.ring5,
        this.ring6,
        this.ring7,
        this.ring8,
        this.ring9,
        this.ring10,
        this.innerRing
    ];

    constructor(caliber: number) {
        super(caliber);

        this.pelletCaliber = caliber;
        this.innerTenRadiusRifle = this.innerRing / 2.0 + this.pelletCaliber / 2.0; //4.75m;
    }


    getBlackRings(): number {
        return this.rifleBlackRings;
    }

    getInnerTenRadius(): number {
        return this.innerTenRadiusRifle;
    }


    getOutterRadius(): number {
        return this.getOutterRing() / 2.0 + this.pelletCaliber / 2.0;
    }

    get10Radius(): number {
        return this.ring10 / 2.0 + this.pelletCaliber / 2.0;
    }

    getTargetType(): TargetType {
        return TargetType.Rifle50m;
    }

    getOutterRing(): number {
        return this.outterRing;
    }

    getProjectileCaliber(): number {
        return this.pelletCaliber;
    }

    getRings(): number[] {
        return this.ringsRifle;
    }

    getSize(): number {
        return this.targetSize;
    }

    isSolidInner(): boolean {
        return this.solidInnerTenRing;
    }


    getFontSize(diff : number) : number {
        return diff / 6.0; 
    }

    getBlackDiameter(): number {
        return this.blackCircle;
    }


    getRingTextCutoff(): number {
        return 8;
    }

    getTextOffset(diff: number, ring: number) {
        if (ring != 3) {
            return 0;
        } else {
            return diff / 12;
        }
    }

    getTextRotation(): number {
        return 0;
    }

    getFirstRing(): number {
        return 1;
    }

    drawEastText(): boolean {
        return true;
    }

    drawNorthText(): boolean {
        return true;
    }

    drawSouthText(): boolean {
        return true;
    }

    drawWestText(): boolean {
        return true;
    }   
}
