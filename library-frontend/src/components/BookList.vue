<template>
    <div class="table-wrapper">
        <table class="list-table">
            <thead>
                <tr>
                    <th v-for="(header, i) in headers" :key="i">
                        {{ header }}
                    </th>
                </tr>
            </thead>

            <tbody>
                <tr v-for="(row, index) in rows" :key="index">
                    <td v-for="(value, i) in row" :key="i">
                        <!-- Status column -->
                        <span v-if="headers[i] === 'Status'"
                              class="status-badge"
                              :class="value.toLowerCase() === 'active' ? 'active' : 'inactive'">
                            {{ value }}
                        </span>

                        <!-- Name column: print name + author -->
                        <span v-else-if="headers[i] === 'Name'" style="font-weight: 500;">
                            {{ value }}
                            <small v-if="headers[i] === 'author'" style="color:#666; margin-left:6px;">
                                {{ value}}
                            </small>
                        </span>


                        <!-- All other columns -->
                        <span v-else>
                            {{ value }}
                        </span>
                    </td>

                    <!-- Desktop view: inline buttons -->
                    <td class="action-cell" v-if="rows.length > 0">
                        <button class="btn btn-warning" @click="$emit('edit', row)">
                            <i class="fas fa-edit"></i> Edit
                        </button>
                        <button class="btn btn-danger" @click="$emit('delete', row)">
                            <i class="fas fa-trash-alt"></i> Delete
                        </button>
                        <button class="btn btn-primary" @click="$emit('assign', row)">
                            <i class="fas fa-handshake"></i> Assign
                        </button>
                        <button class="btn btn-secondary" @click="$emit('view', row)">
                            <i class="fas fa-info-circle"></i> View
                        </button>
                    </td>

                    <!-- Mobile view: dropdown -->
                    <td class="action-cell-mobile" v-if="rows.length > 0">
                        <button class="action-btn btn btn-secondary dropdown-toggle"
                                type="button"
                                data-bs-toggle="dropdown">
                            <i class="fas fa-ellipsis-v"></i>
                        </button>

                        <ul class="dropdown-menu action-dropdown">
                            <li>
                                <a class="dropdown-item" href="#" @click.prevent="$emit('assign', row)">
                                    <i class="fas fa-handshake"></i> Assign
                                </a>
                            </li>
                            <li>
                                <a class="dropdown-item" href="#" @click.prevent="$emit('edit', row)">
                                    <i class="fas fa-edit"></i> Edit
                                </a>
                            </li>
                            <li>
                                <a class="dropdown-item" href="#" @click.prevent="$emit('delete', row)">
                                    <i class="fas fa-trash-alt"></i> Delete
                                </a>
                            </li>
                            <li>
                                <a class="dropdown-item" href="#" @click.prevent="$emit('view', row)">
                                    <i class="fas fa-info-circle"></i> View
                                </a>
                            </li>
                        </ul>
                    </td>
                </tr>

                <!-- Fallback row when no data -->
                <tr v-if="rows.length === 0">
                    <!-- Use headers?.length safely -->
                    <td :colspan="headers ? headers.length : 1" class="no-items">
                        No items found
                    </td>
                </tr>

            </tbody>
        </table>
    </div>
</template>

<script setup>defineProps({
  headers: {
    type: Array,
    required: true
  },
  rows: {
    type: Array,
    required: true
  }
})</script>

<style scoped>
    .table-wrapper {
        width: 100%;
        overflow-x: auto;
        background: #ffffff;
        border-radius: 12px;
        position: relative;
        min-height: 400px;
        border: 1px solid #e0e0e0; /* subtle border */
    }

    .list-table {
        width: 100%;
        border-collapse: collapse;
        color: #333; /* darker text for readability */
        font-size: 14px;
    }

    .list-table thead {
        background: #f9f9f9; /* light gray header */
        text-transform: uppercase;
        font-size: 12px;
        letter-spacing: 0.5px;
    }

    .list-table th,
    .list-table td {
        padding: 10px 14px;
        text-align: left;
        border-bottom: 1px solid #eaeaea; /* subtle row divider */
    }

    .list-table tbody tr:hover {
        background: #f5f5f5; /* soft hover effect */
    }

    /* Status badge */
    .status-badge {
        padding: 4px 10px;
        border-radius: 20px;
        font-size: 12px;
        text-transform: capitalize;
    }

    .status-badge.active {
        background: #e6f7f1;
        color: #00a86b;
    }

    .status-badge.inactive {
        background: #fdeaea;
        color: #d93025;
    }

    /* Actions hide for mobile as action-cell-mobile were used for mobile */
    .action-cell {
        display: none;
    }

    .action-cell-mobile {
        position: relative;
    }

    .action-cell-mobile:hover .action-dropdown {
        display: block;
        z-index:999;
    }

    .action-btn {
        width: 100%;
        height: 36px;
        font-size: 14px;
        border-radius: 6px;
        color: #333;
        background: transparent;
        border: 1px solid #ddd;
    }

    .action-dropdown {
        width: 160px;
        padding: 6px 0;
        border-radius: 8px;
        border: 1px solid #e0e0e0;
        box-shadow: 0 4px 12px rgba(0,0,0,0.05);
        position: absolute;
        background-color: #fff;
        right: 0;
        display: none;
    }

    .action-dropdown li {
        list-style-type: none;
    }

    .action-dropdown .dropdown-item {
        display: flex;
        align-items: center;
        gap: 8px;
        height: 36px;
        font-size: 13px;
        padding: 0 12px;
        color: #333;
    }

    .action-dropdown .dropdown-item i {
        font-size: 14px;
    }

    .action-dropdown .dropdown-item:hover {
        background-color: #f5f5f5;
    }
    .no-items{
        text-align:center;
    }
    /* Responsive */
    @media (max-width: 576px) {
        .action-btn {
            font-size: 13px;
            height: 34px;
        }

        .action-dropdown {
            width: 140px;
        }

        .action-dropdown .dropdown-item {
            font-size: 14px;
            height: 40px
        }
    }

    @media screen and (min-width: 600px) {

        .table-wrapper{
            overflow:hidden;
        }
        .status-badge{
            font-size:14px;
        }
        
        .action-cell-mobile {
            display: none;
        }
        

        .action-cell {
            display: flex;
            flex-direction: row;
            gap: 8px;
        }

        .action-cell button {
            border-radius: 6px;
            font-size: 13px;
            padding: 6px 10px;
        }
        .btn {
            transition: transform 0.2s ease, box-shadow 0.2s ease;
        }

        /* Hover effect */
        .btn:hover {
            transform: scaleX(1.05); /* widen slightly */
            box-shadow: 0 4px 8px rgba(0,0,0,0.15);
        }

        /* Active (click) effect */
        .btn:active {
            transform: scaleX(0.95); /* compress horizontally */
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        .btn-danger{
            background-color:red;
        }
        .btn-warning{
            background-color:orange;
        }
        .btn-primary{
            background-color:limegreen;
        }
        .btn-secondary{
            background-color:darkgray;
        }
    }
</style>