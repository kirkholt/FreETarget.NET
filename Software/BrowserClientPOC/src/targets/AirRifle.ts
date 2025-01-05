import { aTarget } from "./aTarget";
import { TargetType } from "./TargetType";

export class AirRifle extends aTarget {
    private pelletCaliber: number;
    private targetSize: number = 80; //mm
    private rifleBlackRings: number = 4;
    private solidInnerTenRing: boolean = true;


    private outterRing: number = 45.5; //mm
    private ring2: number = 40.5; //mm
    private ring3: number = 35.5; //mm
    private ring4: number = 30.5; //mm
    private ring5: number = 25.5; //mm
    private ring6: number = 20.5; //mm
    private ring7: number = 15.5; //mm
    private ring8: number = 10.5; //mm
    private ring9: number = 5.5; //mm
    private ring10: number = 0.5; //mm

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
        this.ring10
    ];

    constructor(caliber: number) {
        super(caliber);

        this.pelletCaliber = caliber;
        this.innerTenRadiusRifle = this.pelletCaliber / 2.0 - this.ring10 / 2.0; //2.0m; ISSF rules states: Inner Ten = When the 10 ring (dot) has been shot out completely
    }

   getTargetType(): TargetType {
        return TargetType.AirRifle;
    }
    getProjectileCaliber(): number {
        return this.pelletCaliber;
    }
    getSize(): number {
        return this.targetSize;
    }
    getRings(): number[] {
        return this.ringsRifle;
    }
    getOutterRing(): number {
        return this.outterRing;
    }
    getOutterRadius(): number {
        return this.getOutterRing() / 2.0 + this.pelletCaliber / 2.0;
    }
    get10Radius(): number {
        return this.ring10 / 2.0 + this.pelletCaliber / 2.0;
    }
    getInnerTenRadius(): number {
        return this.innerTenRadiusRifle;
    }
    getBlackRings(): number {
        return this.rifleBlackRings;
    }
    getBlackDiameter(): number {
        return this.ring4;
    }
    isSolidInner(): boolean {
        return this.solidInnerTenRing;
    }
    getRingTextCutoff(): number {
        return 8;
    }
    getTextOffset(diff: number, ring: number) {
        return 0;
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
    getFontSize(diff: number) {
        return diff / 8.0;
    }
}
